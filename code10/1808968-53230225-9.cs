	using System;
	using System.Collections.Generic;
	namespace ObjectListView_TreeListView
	{
		class FooTreeListView : BrightIdeasSoftware.TreeListView
		{
			private List<Categories> categoriesList;
			private readonly string[] categoryDescriptors = { "Cat A", "Cat B", "Cat C", "Cat D" };
			internal List<Categories> CategoriesList { get => categoriesList; set => categoriesList = value; }
			public enum CategoryEnum
			{
				CategoryA = 0,
				CategoryB = 1,
				CategoryC = 2,
				CategoryD = 3
			}
			public FooTreeListView() : base()
			{
				CategoriesList = new List<Categories>();
				CategoriesList.Clear();
				CanExpandGetter = delegate (Object x)
				{
					if (x is Categories && ((Categories)x).ItemList.Count > 0)
					{
						return true;
					}
					if (x is Categories.Item && ((Categories.Item)x).ActionList.Count > 0)
					{return true;
					}
					return false;
				};
				ChildrenGetter = delegate (Object x)
				{
					if (x is Categories)
						return ((Categories)x).ItemList;
					if (x is Categories.Item)
						return ((Categories.Item)x).ActionList;
					throw new ArgumentException("Should be Categories or Categories.Item");
				};
				//Load the 4 top-level categories into the tree
				CategoriesList.Add(new Categories(categoryDescriptors[(int)CategoryEnum.CategoryA],false));
				CategoriesList.Add(new Categories(categoryDescriptors[(int)CategoryEnum.CategoryB], false));
				CategoriesList.Add(new Categories(categoryDescriptors[(int)CategoryEnum.CategoryC], false));
				CategoriesList.Add(new Categories(categoryDescriptors[(int)CategoryEnum.CategoryD], false));
			}
			internal class Categories
			{
				private string action;
				private bool? isChecked;
				public string Action { get { return action; } set { action = value; } }
				public bool? IsChecked { get => isChecked; set => isChecked = value; }
				private List<Item> itemList;
				internal List<Item> ItemList { get => itemList; set => itemList = value; }
				public Categories(string action, bool? isChecked)
				{
					this.action = action;
					this.isChecked = isChecked;
					ItemList = new List<Item>();
				}
				internal class Item
				{
					private string action;
					private bool? isChecked;
					private int numberToKeep = 0;
					private List<ItemAction> actionList;
					public string Action { get { return action; } set { action = value; } }
					public int NumberToKeep { get => numberToKeep; set => numberToKeep = value; }
					public bool? IsChecked { get => isChecked; set => isChecked = value; }
					internal List<ItemAction> ActionList { get => actionList; set => actionList = value; }
					internal Item(string action, bool? isChecked, int numberToKeep)
					{
						this.action = action;
						this.isChecked = isChecked;
						this.NumberToKeep = numberToKeep;
						ActionList = new List<ItemAction>();
					}
					internal class ItemAction
					{
						private string action;
						private bool? isChecked;
						public string Action { get { return action; } set { action = value; } }
						public bool? IsChecked { get { return isChecked; } set { isChecked = value; } }
						internal ItemAction(string action, bool? isChecked)
						{
							this.action = action;
							this.isChecked = isChecked;
						}
					}
				}
			}
			public void AddCategoryItemName(CategoryEnum category, string itemName, bool? isChecked, int numberToKeep)
			{
				CategoriesList[(int)category].ItemList.Add(new Categories.Item(itemName, isChecked, numberToKeep));
			}
			public void AddItemAction(CategoryEnum category, string itemName, string action, Boolean isChecked)
			{
				Categories.Item itemMatch = CategoriesList[(int)category].ItemList.Find(x => x.Action.Equals(itemName));
				if (itemMatch != null)
				{
					itemMatch.ActionList.Add(new Categories.Item.ItemAction(action, isChecked));
				}
				else
				{
					throw new ArgumentException(String.Format("Can't find treeviewlist item '{0}'->'{1}'", categoryDescriptors[(int)category], itemName));
				}
			}
			public void AddItemAction(CategoryEnum category, string itemName, string action)
			{
				Categories.Item itemMatch = CategoriesList[(int)category].ItemList.Find(x => x.Action.Equals(itemName));
				if (itemMatch != null)
				{
					itemMatch.ActionList.Add(new Categories.Item.ItemAction(action, false));
				}
				else
				{
					throw new ArgumentException(String.Format("Can't find treeviewlist item '{0}'->'{1}'", categoryDescriptors[(int)category], itemName));
				}
			}
			public void LoadTree()
			{
				Roots = CategoriesList;
				ExpandAll();
			}
		}
	}
