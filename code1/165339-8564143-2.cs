    public partial class MyForm : Form
    {
        public MyForm()
        {
            if (ShouldClose())
            {
                Load += (s, e) => Close();
                return;
            }
            // ...
        }
        // ...
    }
