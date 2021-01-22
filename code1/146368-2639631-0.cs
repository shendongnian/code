        public partial class InstrumentoBase : System.Web.UI.Page
        {
        
        public string INST_Emplazamiento
        {
                 get {return "Some Value"  );}
        }
        public TextBox DevolverTextBoxdeMaster(string sNombreTextBox)
              {
                 TextBox Texto;
                 Texto = (TextBox)Master.FindControl(sNombreTextBox);
                 return Texto;
              }
    }
