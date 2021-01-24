    public CtrlScroll() {
            InitializeComponent();
            scbMain.Scroll += ( sender, e ) => {
                //Normally the if statement whouldn't be needed but the metro srollbar
                //has a weird behaviour when the scroll value becomes max
                if( scbMain.Value > panel1.Height - this.Height ) {
                    panel1.Top = -( panel1.Height - this.Height );
                }
                else {
                    panel1.Top = -scbMain.Value;
                };
            };
            int maxVertical = panel1.Height;
            // SmallChange is typically 1%.
            int smallChangeVertical = Math.Max( (int)( maxVertical / 100 ), 1 );
            // LargeChange is one page.
            int largeChangeVertical = this.Height;
            scbMain.Minimum = 0;
            scbMain.Maximum = maxVertical;
            scbMain.SmallChange = smallChangeVertical;
            scbMain.LargeChange = largeChangeVertical;
        }
