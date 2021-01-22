    public partial class refAndOutUse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myClass myRefObj;
            myRefObj = new myClass { Name = "ref outside called!!  <br/>" };
            myRefFunction(ref myRefObj);
            Response.Write(myRefObj.Name); //ref inside function
            myClass myOutObj;
            myOutFunction(out myOutObj);
            Response.Write(myOutObj.Name); //out inside function
        }
        void myRefFunction(ref myClass refObj)
        {
            refObj.Name = "ref inside function <br/>";
            Response.Write(refObj.Name); //ref inside function
        }
        void myOutFunction(out myClass outObj)
        {
            outObj = new myClass { Name = "out inside function <br/>" }; 
            Response.Write(outObj.Name); //out inside function
        }
    }
    public class myClass
    {
        public string Name { get; set; }
    } 
