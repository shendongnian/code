    public partial class PerfilAcesso : Form
    {
         public PerfilAcesso () 
         {
            bdeForm = new BDE(this); 
            workshopForm = new Workshop(this); 
         }
         BDE bdeForm;
         Workshop workshopForm;
    }
