    using System;
    using System.Windows.Forms;
    using SomeNamespaceWithMyDataContext;
    static class Program
    {
        [STAThread]
        static void Main() {
            MyDataContext ctx = new MyDataContext();
            BindingSource custs = new BindingSource() {
                DataSource = ctx.Customers};
    
            BindingSource orders = new BindingSource {
                DataMember = "Orders", DataSource = custs};
    
            Button btn;
            using (Form form = new Form
            {
                Controls = {
                    new DataGridView() {
                        DataSource = orders, DataMember = "Order_Details",
                        Dock = DockStyle.Fill},
                    new ComboBox() {
                        DataSource = orders, DisplayMember = "OrderID",
                        Dock = DockStyle.Top},
                    new ComboBox() {
                        DataSource = custs, DisplayMember = "CompanyName",
                        Dock = DockStyle.Top},                
                    (btn = new Button() {
                        Text = "Save", Dock = DockStyle.Bottom
                        })
                }
            })
            {
                btn.Click += delegate {
                    form.Text = "Saving...";
                    ctx.SubmitChanges();
                    form.Text = "Saved";
                };
                Application.Run(form);
            }
        }
    }
