    namespace WpfApplication1 {
        
        
        /// <summary>
        /// App
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public partial class App : System.Windows.Application {
            
            /// <summary>
            /// InitializeComponent
            /// </summary>
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void InitializeComponent() {
                
                #line 4 "..\..\..\App.xaml"
                this.StartupUri = new System.Uri("MainWindow.xaml", System.UriKind.Relative);
                
                #line default
                #line hidden
            }
            
            /// <summary>
            /// Application Entry Point.
            /// </summary>
            [System.STAThreadAttribute()]
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static void Main() {
                WpfApplication1.App app = new WpfApplication1.App();
                app.InitializeComponent();
                app.Run();
            }
        }
    }
