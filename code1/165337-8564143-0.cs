    public partial class MyForm : Form
    {
        public MyForm()
        {
            if (ShouldClose())
            {
                Shown += (s, e) => Close();
                return;
            }
            // ...
        }
        // ...
    }
