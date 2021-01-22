    public partial class usrctrlSimulator : UserControl
    {
       public usrctrlSimulator()
       {
          this.InitializeComponent();          
       }
       public void StartSimulator()
       {
          _algorithm= new csAlgorithm();
          _algorithm.InitializeSimulator();
          timer1.Start();
       }
       
       private csAlgorithm _algorithm;
    }
    public class csAlgorithm // not a UserControl anymore
    {
       public csAlgorithm()
          {
          }
       public void InitializeSimulator()
       {
          txtblkSimulatorStatus.Text = "Started"; // this element would be from the user control
       }
    }
