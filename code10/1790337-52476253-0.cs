    class MainForm: Form {
        public MainForm()
        {
            this.Build();
        }
        void Build()
        {
            this.root =  new Panel { Dock = DockStyle.Fill };
            // create all controls and add them to root
    
            this.Controls.Add( root );
            this.ResizeBegin += (obj, args) => this.OnResizeBegin();
            this.ResizeEnd += (obj, args) => this.OnResizeEnd();
        }
     
        void OnResizeBegin()
        {
            this.root.SuspendLayout();
        }
        void OnResizeEnd()
        {    
            this.root.ResumeLayout( true );
        }
    
        Panel root;
    }
