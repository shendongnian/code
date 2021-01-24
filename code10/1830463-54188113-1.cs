	using BrightIdeasSoftware;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Windows.Forms;
	namespace NovaSysEng
	{
		class ClsTriStateTreeListView : BrightIdeasSoftware.TreeListView
		{
			private readonly bool showHeaderCheckBox = false;
			private List<ClsItem> itemList;
			readonly OLVColumn olvColumnName;
			readonly OLVColumn olvColumnFoo;
			/// <summary>
			/// CTOR
			/// </summary>
			public ClsTriStateTreeListView() : this(false)
			{
			}
			/// <summary>
			/// CTOR
			/// </summary>
			/// <param name="showHeaderCheckBox"></param>
			public ClsTriStateTreeListView(bool showHeaderCheckBox) : base()
			{
				this.showHeaderCheckBox = showHeaderCheckBox;
				CheckBoxes = true;
				View = View.Details;
				UseAlternatingBackColors = true;
				MultiSelect = false;
				CheckedAspectName = "";
				GridLines = true;
				OwnerDraw = true;
				ShowGroups = false;
				TriStateCheckBoxes = true;
				VirtualMode = true;
				HierarchicalCheckboxes = false;
				ItemChecked += FooTreeListView_ItemChecked;
				HeaderCheckBoxChanging += ClsFooTreeListView_HeaderCheckBoxChanging;
				itemList = new List<ClsItem>();
				olvColumnName = new BrightIdeasSoftware.OLVColumn
				{
					AspectName = "Name",
					Text = "Name",
					HeaderCheckBoxUpdatesRowCheckBoxes = false
				};
				AllColumns.Add(olvColumnName);
				Columns.Add(olvColumnName);
				olvColumnFoo = new BrightIdeasSoftware.OLVColumn
				{
					AspectName = "Foo",
					Text = "Foo",
				};
				AllColumns.Add(olvColumnFoo);
				Columns.Add(olvColumnFoo);
				
				// Don't allow the user to put a checkbox in the indeterminate state.
				// When clicked, a checkbox cycles through 3 states in the order: checked, indeterminate, unchecked
				// So, if the checkbox state is Indeterminate, force it to unchecked.
				// An exception is when a checkbox has the Indeterminate setting and the model IgnoreIndeterminate
				// property is true. This is for the case when we want to set the checkbox to Indeterminate
				// programattically and have it stick.
				CheckStatePutter = delegate (Object rowObject, CheckState newValue)
				{
					if (newValue == CheckState.Indeterminate && ((ClsItem)rowObject).IgnoreIndeterminate)
					{
						return CheckState.Indeterminate;
					}
					else if (newValue == CheckState.Indeterminate)
					{
						return CheckState.Unchecked;
					}
					else
					{
						return newValue;
					}
				};
				CanExpandGetter = delegate (Object x)
				{
					return ((ClsItem)x).Children.Count > 0;
				};
				ChildrenGetter = delegate (Object x)
				{
					return ((ClsItem)x).Children;
				};
			}
			/// <summary>
			/// If the user clicks on the HeaderCheckBox, set all descendants accordingly
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void ClsFooTreeListView_HeaderCheckBoxChanging(object sender, HeaderCheckBoxChangingEventArgs e)
			{
				ItemChecked -= FooTreeListView_ItemChecked;
				foreach (ClsItem topLevelItem in this.Objects)
				{
					if (e.NewCheckState == CheckState.Checked)
					{
						CheckObject(topLevelItem);
						CheckDescendantCheckboxes(topLevelItem);
					}
					else
					{
						UncheckObject(topLevelItem);
						UncheckDescendantCheckboxes(topLevelItem);
					}
				}
				ItemChecked += FooTreeListView_ItemChecked;
			}
			/// <summary>
			/// Set the model IgnoreIndeterminate property to true then set the checkbox to Indeterminate
			/// using the CheckIndeterminateObject method. CheckStatePutter will be invoked and the 
			/// Indeterminate setting will be ignored for this particular case. Finally, set the model
			/// IgnoreIndeterminate property to false so an Indeterminate checkbox setting will otherwise
			/// be change to an Unchecked setting.
			/// </summary>
			/// <param name="rowObject"></param>
			public override void CheckIndeterminateObject(object rowObject)
			{
				((ClsItem)rowObject).IgnoreIndeterminate = true;
				base.CheckIndeterminateObject(rowObject);
				((ClsItem)rowObject).IgnoreIndeterminate = false;
			}
			private void UncheckDescendantCheckboxes(ClsItem objTreeItemModel)
			{
				foreach (ClsItem child in GetChildren(objTreeItemModel))
				{
					UncheckObject(child);
					UncheckDescendantCheckboxes(child);
				}
			}
			private void CheckDescendantCheckboxes(ClsItem objTreeItemModel)
			{
				foreach (ClsItem child in GetChildren(objTreeItemModel))
				{
					CheckObject(child);
					CheckDescendantCheckboxes(child);
				}
			}
			private void FooTreeListView_ItemChecked(object sender, ItemCheckedEventArgs e)
			{
				Console.WriteLine("In FooTreeListView_ItemChecked");
				ItemChecked -= FooTreeListView_ItemChecked;
				ClsItem objTreeItemModel = (ClsItem)((OLVListItem)e.Item).RowObject;
				//set descendant checkboxes
				if (IsChecked(objTreeItemModel))
				{
					CheckDescendantCheckboxes(objTreeItemModel);
				}
				else
				{
					UncheckDescendantCheckboxes(objTreeItemModel);
				}
				ClsItem objTreeItemModelParent = (ClsItem)GetParent(objTreeItemModel);
				//Set ancestor checkboxes 
				while (objTreeItemModelParent != null)
				{
					bool allChildrenChecked = true;
					bool allChildrenUnchecked = true;
					// If all 1st generation children of the parent are checked, set parent to checked
					// If all 1st generation children of the parent are unchecked, set parent to unchecked
					// Otherwise, set parent to indeterminte
					foreach (ClsItem child in GetChildren(objTreeItemModelParent))
					{
						if (IsChecked(child))
						{
							allChildrenUnchecked = false;
						}
						if (!IsChecked(child))
						{
							allChildrenChecked = false;
						}
						if (IsCheckedIndeterminate(child))
						{
							allChildrenUnchecked = false;
							allChildrenChecked = false;
							break;
						}
					}
					if (allChildrenChecked)
					{
						CheckObject(objTreeItemModelParent);
					}
					else if (allChildrenUnchecked)
					{
						UncheckObject(objTreeItemModelParent);
					}
					else
					{
						CheckIndeterminateObject(objTreeItemModelParent);
					}
					objTreeItemModelParent = (ClsItem)GetParent(objTreeItemModelParent);
				} // while
				
				if (showHeaderCheckBox)
				{
					bool allChecked = true;
					bool allUnchecked = true;
					foreach (ClsItem topLevelItem in this.Objects)
					{
						if (IsChecked(topLevelItem))
						{
							allUnchecked = false;
						}
						if (!IsChecked(topLevelItem))
						{
							allChecked = false;
						}
						if (IsCheckedIndeterminate(topLevelItem))
						{
							allUnchecked = false;
							allChecked = false;
							break;
						}
					}
					HeaderCheckBoxChanging -= ClsFooTreeListView_HeaderCheckBoxChanging;
					if (allChecked)
					{
						CheckHeaderCheckBox(olvColumnName);
					}
					else if (allUnchecked)
					{
						UncheckHeaderCheckBox(olvColumnName);
					}
					else
					{
						CheckIndeterminateHeaderCheckBox(olvColumnName);
					}
					HeaderCheckBoxChanging += ClsFooTreeListView_HeaderCheckBoxChanging;
				} // if (showHeaderCheckBox)
				ItemChecked += FooTreeListView_ItemChecked;
			} // private void FooTreeListView_ItemChecked(object sender, ItemCheckedEventArgs e)
			public void AddItem(int id, int parentId, string name, bool? isChecked, string foo)
			{
				itemList.Add(new ClsItem(id, parentId, name, isChecked, foo));
			}
			/// <summary>
			/// After using the AddItem method to add tree items, call this method to load the model into the TreeListView.
			/// https://stackoverflow.com/questions/9409021/id-parentid-list-to-hierarchical-list
			/// </summary>
			public void Load()
			{
				itemList.ForEach(item => item.Children = itemList.Where(child => child.ParentId == item.Id).ToList());
				List<ClsItem> topItems = itemList.Where(item => item.ParentId == 0).ToList();
				((OLVColumn)this.Columns[0]).HeaderCheckBox = this.showHeaderCheckBox;
				Roots = topItems;
			}
			/// <summary>
			/// This model supports the creation of a tree hierarchy whose depth is not known until run time
			/// https://stackoverflow.com/questions/9409021/id-parentid-list-to-hierarchical-list
			/// </summary>
			private class ClsItem
			{
				int id;
				int parentId;
				string name;
				bool? isChecked;
				string foo;
				List<ClsItem> children = new List<ClsItem>();
				bool ignoreIndeterminate;
				public ClsItem(int id, int parentId, string name, bool? isChecked, string foo)
				{
					this.id = id;
					this.parentId = parentId;
					this.name = name;
					this.isChecked = isChecked;
					this.foo = foo;
				}
				public bool? IsChecked { get => isChecked; set => isChecked = value; }
				public string Name { get => name; set => name = value; }
				public string Foo { get => foo; set => foo = value; }
				public int Id { get => id; set => id = value; }
				public int ParentId { get => parentId; set => parentId = value; }
				public List<ClsItem> Children { get => children; set => children = value; }
				public bool IgnoreIndeterminate { get => ignoreIndeterminate; set => ignoreIndeterminate = value; }
			}
		}
	}
