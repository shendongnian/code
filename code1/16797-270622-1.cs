	using System;
	using System.Drawing;
	using System.ComponentModel;
	using System.Windows.Forms;
	class ListBoxWrapper: ListBox {
		protected override void OnSelectedIndexChanged (EventArgs a) {
			if (DataManager != null) {
				DataManager.SuspendBinding();
			}
		}
	}
	class Program {
		static BindingList<string> list = new BindingList<string>();
		static void HandleClick (object o, EventArgs a) {
			list.Add(DateTime.Now.ToString());
		}
		static void Main () {
			Form f = new Form();
			ListBox b0 = new ListBoxWrapper();
			ListBox b1 = new ListBoxWrapper();
			b0.DataSource = list;
			b1.DataSource = list;
			Button b2 = new Button();
			b2.Click += new EventHandler(HandleClick);
			f.Controls.Add(b0);
			f.Controls.Add(b1);
			f.Controls.Add(b2);
			b1.Location = new Point(0, b0.Height);
			b2.Location = new Point(0, b1.Location.Y + b1.Height);
			Application.Run(f);
		}
	}
