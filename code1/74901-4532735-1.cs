     public partial class StaticVsNonStatic_StaticVsNonWorkplace : System.Web.UI.Page
     {
         protected void Page_Load(object sender, EventArgs e)
         {
            StaticVsNonStatic objStaticVsNonStatic = new StaticVsNonStatic();
            lblDisplayNS.Text = objStaticVsNonStatic.NonStaticMethod(); //Non Static 
            lblDisplayS.Text =  StaticVsNonStatic.StaticMethod();  //Static and called without object
         }
     }
