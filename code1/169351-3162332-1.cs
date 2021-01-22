    public partial class _Default : System.Web.UI.Page
    {
        IEnumerable<int> table1;
        IEnumerable<int> table2;
        protected void Page_Load(object sender, EventArgs e)
        {
            table1 = Enumerable.Range(0, 10);
            table2 = Enumerable.Range(10, 10);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            var query = 
                Observable.If(() => CheckBox1.Checked,
                    (from t in table1 select t).ToObservable(), Observable.Empty<int>())
                .Concat(
                    Observable.If(() => CheckBox2.Checked,
                    (from t in table2 select t).ToObservable(), Observable.Empty<int>())
                );
            query.Subscribe(i => Response.Write(i));
        }
    }
