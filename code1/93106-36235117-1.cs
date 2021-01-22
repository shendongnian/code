	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Runtime.InteropServices;
	using System.Windows.Forms;
	namespace TreeTest
	{
	  static class Program
	  {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
		  Application.EnableVisualStyles();
		  Application.SetCompatibleTextRenderingDefault(false);
		  Application.Run(new TreeForm());
		}
	  }
	  public static class NativeExtensions
	  {
		public const int TVS_NONEVENHEIGHT = 0x4000;
		[DllImport("user32")]
		//private static extern IntPtr SendMessage(IntPtr hwnd, uint msg, IntPtr wp, IntPtr lp);
		private static extern IntPtr SendMessage(IntPtr hwnd, uint msg, IntPtr wp, ref TVITEMEX lp);
		private const int TVM_GETITEM = 0x1100 + 62;
		private const int TVM_SETITEM = 0x1100 + 63;
		[StructLayout(LayoutKind.Sequential)]
		private struct TVITEMEX
		{
		  public uint mask;
		  public IntPtr hItem;
		  public uint state;
		  public uint stateMask;
		  public IntPtr pszText;
		  public int cchTextMax;
		  public int iImage;
		  public int iSelectedImage;
		  public int cChildren;
		  public IntPtr lParam;
		  public int iIntegral;
		  public uint uStateEx;
		  public IntPtr hwnd;
		  public int iExpandedImage;
		  public int iReserved;
		}
		[Flags]
		private enum Mask : uint
		{
		  Text = 1,
		  Image = 2,
		  Param = 4,
		  State = 8,
		  Handle = 16,
		  SelectedImage = 32,
		  Children = 64,
		  Integral = 128,
		}
		/// <summary>
		/// Get a node's height. Will throw an error if the Node has not yet been added to a TreeView,
		/// as it's handle will not exist.
		/// </summary>
		/// <param name="tn">TreeNode to work with</param>
		/// <returns>Height in multiples of ItemHeight</returns>
		public static int GetHeight(this TreeNode tn)
		{
		  TVITEMEX tvix = new TVITEMEX
		  {
			mask = (uint)(Mask.Handle | Mask.Integral),
			hItem = tn.Handle,
			iIntegral = 0
		  };
		  SendMessage(tn.TreeView.Handle, TVM_GETITEM, IntPtr.Zero, ref tvix);
		  return tvix.iIntegral;
		}
		/// <summary>
		/// Set a node's height. Will throw an error if the Node has not yet been added to a TreeView,
		/// as it's handle will not exist.
		/// </summary>
		/// <param name="tn">TreeNode to work with</param>
		/// <param name="height">Height in multiples of ItemHeight</param>
		public static void SetHeight(this TreeNode tn, int height)
		{
		  TVITEMEX tvix = new TVITEMEX
		  {
			mask = (uint)(Mask.Handle | Mask.Integral),
			hItem = tn.Handle,
			iIntegral = height
		  };
		  SendMessage(tn.TreeView.Handle, TVM_SETITEM, IntPtr.Zero, ref tvix);
		}
	  }
	  public class TreeViewTest : TreeView
	  {
		public TreeViewTest()
		{
		  // Do DoubleBuffered painting
		  SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		  SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		  // Set value for owner drawing ...
		  DrawMode = TreeViewDrawMode.OwnerDrawAll;
		}
		/// <summary>
		/// For TreeNodes to support variable heights, we need to apply the
		/// TVS_NONEVENHEIGHT style to the control.
		/// </summary>
		protected override CreateParams CreateParams
		{
		  get
		  {
			var cp = base.CreateParams;
			cp.Style |= NativeExtensions.TVS_NONEVENHEIGHT;
			return cp;
		  }
		}
		/// <summary>
		/// Do not tempt anyone to change the DrawMode property, be it via code or via
		/// Property grid. It's still possible via code though ...
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		  EditorBrowsable(EditorBrowsableState.Never)]
		public new TreeViewDrawMode DrawMode
		{
		  get { return base.DrawMode; }
		  set { base.DrawMode = value; }
		}
		/// <summary>
		/// OwnerDraw code. Still needs a lot of work, no tree lines, symbols, checkboxes etc. are drawn
		/// yet, just the plain item text and background ...
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDrawNode(DrawTreeNodeEventArgs e)
		{
		  e.DrawDefault = false;
		  // Draw window colour background
		  e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
		  // Draw selected item background
		  if (e.Node.IsSelected)
			e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Node.Bounds);
		  // Draw item text
		  TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, e.Node.Bounds,
			e.Node.IsSelected ? SystemColors.HighlightText : SystemColors.WindowText,
			Color.Transparent, TextFormatFlags.Top | TextFormatFlags.NoClipping);
		  // Draw focus rectangle
		  if (Focused && e.Node.IsSelected)
			ControlPaint.DrawFocusRectangle(e.Graphics, e.Node.Bounds);
		  base.OnDrawNode(e);
		}
		/// <summary>
		/// Without this piece of code, for some reason, drawing of items that get selected/unselected
		/// is deferred until MouseUp is received.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
		  base.OnMouseDown(e);
		  TreeNode clickedNode = GetNodeAt(e.X, e.Y);
		  if (clickedNode.Bounds.Contains(e.X, e.Y))
		  {
			SelectedNode = clickedNode;
		  }
		}
	  }
	  public class TreeForm : Form
	  {
		public TreeForm() { InitializeComponent(); }
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
		  if (disposing && (components != null))
		  {
			components.Dispose();
		  }
		  base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
		  this.treeViewTest1 = new TreeTest.TreeViewTest();
		  this.SuspendLayout();
		  // 
		  // treeViewTest1
		  // 
		  this.treeViewTest1.Dock = System.Windows.Forms.DockStyle.Fill;
		  this.treeViewTest1.Location = new System.Drawing.Point(0, 0);
		  this.treeViewTest1.Name = "treeViewTest1";
		  this.treeViewTest1.Size = new System.Drawing.Size(284, 262);
		  this.treeViewTest1.TabIndex = 0;
		  // 
		  // Form2
		  // 
		  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		  this.ClientSize = new System.Drawing.Size(284, 262);
		  this.Controls.Add(this.treeViewTest1);
		  this.Name = "Form2";
		  this.Text = "Form2";
		  this.ResumeLayout(false);
		}
		private TreeViewTest treeViewTest1;
		protected override void OnLoad(EventArgs e)
		{
		  base.OnLoad(e);
		  AddNodes(treeViewTest1.Nodes, 0, new Random());
		}
		private void AddNodes(TreeNodeCollection nodes, int depth, Random r)
		{
		  if (depth > 2) return;
		  for (int i = 0; i < 3; i++)
		  {
			int height = r.Next(1, 4);
			TreeNode tn = new TreeNode { Text = $"Node {i + 1} at depth {depth} with height {height}" };
			nodes.Add(tn);
			tn.SetHeight(height);
			AddNodes(tn.Nodes, depth + 1, r);
		  }
		}
	  }
	}
