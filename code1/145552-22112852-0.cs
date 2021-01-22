    using ...
    using System.Windows.Media;
    Namespace yourNamespaceName
    {
    ///<summary>
    ///Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
 
        {
           method_Call_Here();     /*call your pre-written method w/ all the code                               *you  wish to
                                *run on project load. It is wise to set the method access
                                *modifier to 'private' so as to minimize security risks.*/
           
               playTada();
           InitializeComponent();
        }
    //all other code ---------------------------------------------------------------------
    private void playTada()
                {
                   var player = new System.Media.SoundPlayer();
                   player.Stream = Properties.Resources.tada;
                   player.Play();
                 //add garbage collection before initialization of main window
                   GC.Collect();
                   GC.WaitForPendingFinalizers();
                }
    } 
    }
    </code></pre>
Hope this helps those that are searching.   :-)
