	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Text.RegularExpressions;
	using System.Windows.Forms;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			private readonly Dictionary<Rectangle, Uri> _links = new Dictionary<Rectangle, Uri>();
			private readonly Regex _reLink = new Regex("href=['\"](?<link>.*?)['\"]");
			private const string _html =
				"<html><body><br><div style='top:20px;left:50px;border:solid 1px red'><a href='http://www.cnn.com'>CNN</a></div><br><font size='14'>xx</font><a href='http://stackoverflow.com'>stackoverflow</a></body></html>";
			private bool _isEditMode;
			public Form1()
			{
				InitializeComponent();
				webBrowser1.DocumentText = _html;
				webBrowser1.Document.Click += Document_Click;
				webBrowser1.Document.MouseMove += Document_MouseMove;
			}
			private void Document_MouseMove(object sender, HtmlElementEventArgs e)
			{
				if (!_isEditMode) return;
				ChangeCursorIfOverLink(e);
			}
			private void ChangeCursorIfOverLink(HtmlElementEventArgs e)
			{
				foreach (KeyValuePair<Rectangle, Uri> link in _links)
				{
					if (CursorWithinControl(e, link.Key))
					{
						if (Cursor.Current != Cursors.Hand)
							Cursor.Current = Cursors.Hand;
						return;
					}
				}
				Cursor.Current = Cursors.Default;
			}
			private void Document_Click(object sender, HtmlElementEventArgs e)
			{
				NavigateLinkInEditMode(e);
			}
			private void NavigateLinkInEditMode(HtmlElementEventArgs e)
			{
				if (_isEditMode)
				{
					foreach (KeyValuePair<Rectangle, Uri> link in _links)
					{
						if (CursorWithinControl(e, link.Key))
						{
							webBrowser1.Navigate(link.Value);
							return;
						}
					}
				}
			}
			private bool CursorWithinControl(HtmlElementEventArgs e, Rectangle rectangle)
			{
				return e.MousePosition.X >= rectangle.Left
					   && e.MousePosition.X <= rectangle.Left + rectangle.Width
					   && e.MousePosition.Y >= rectangle.Top
					   && e.MousePosition.Y <= rectangle.Top + rectangle.Height;
			}
			private void button1_Click(object sender, EventArgs e)
			{
				RecordLinkPositions();
				webBrowser1.Document.ExecCommand("EditMode", false, null);
				webBrowser1.DocumentText = _html;
				_isEditMode = true;
			}
			private void RecordLinkPositions()
			{
				foreach (HtmlElement element in webBrowser1.Document.All)
				{
					if (element.TagName == "A")
					{
						string url = _reLink.Match(element.OuterHtml).Groups["link"].Value;
						_links.Add(element.OffsetRectangle, new Uri(url));
					}
				}
			}
		}
	}
