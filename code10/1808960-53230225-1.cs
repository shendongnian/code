	using System.Windows.Forms;
	using static ObjectListView_TreeListView.FooTreeListView;
	namespace ObjectListView_TreeListView
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
				SuspendLayout();
				xenSnapshotsTreeListView1.AddCategoryItemName(CategoryEnum.CategoryA, "Item A", true, 0);
				xenSnapshotsTreeListView1.AddCategoryItemName(CategoryEnum.CategoryA, "Item B", false, 1);
				xenSnapshotsTreeListView1.AddItemAction(CategoryEnum.CategoryA, "Item A", "Item A foo", true);
				xenSnapshotsTreeListView1.AddItemAction(CategoryEnum.CategoryA, "Item A", "Item A bar", false);
				xenSnapshotsTreeListView1.AddItemAction(CategoryEnum.CategoryA, "Item B", "Item B foo");
				xenSnapshotsTreeListView1.AddItemAction(CategoryEnum.CategoryA, "Item B", "Item B bar", true);
				xenSnapshotsTreeListView1.LoadTree();
				ResumeLayout();
			}
		}
	}
