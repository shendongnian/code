    using ...
    using System.Windows.Media;
    Namespace yourNamespace_Name
    {
    /// sumary >
    ///Interaction logic for MainWindow.xaml
    /// /sumary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
 
        {
                       /*call your pre-written method w/ all the code you  wish to
                                *run on project load. It is wise to set the method access
                                *modifier to 'private' so as to minimize security risks.*/
           
               playTada();       //method call
           InitializeComponent();
        }
     //all other code ---------------------------------------------------------------------
    // method
    private void playTada()
                {
                   var player = new System.Media.SoundPlayer();
                   player.Stream = Properties.Resources.tada;
          // add the waveFile to resources, the easiest way is to copy the file to
          // the desktop, resize the IDE window so the file is visible, right 
          // click the Project in the solution explorer & select properties, click
          // the resources tab, & drag and drop the wave file into the resources 
          // window. Then just reference it in the method.
          // for example: "player.Stream = Properties.Resources.tada;"         
                   player.Play();
                 //add garbage collection before initialization of main window
                   GC.Collect();
                   GC.WaitForPendingFinalizers();
                }
    } 
    }
    </code></pre>
Hope this helps those that are searching.   :-)
