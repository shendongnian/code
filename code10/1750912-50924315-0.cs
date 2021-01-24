    class CustomControl : Control
    {
        public ICommand CustomControlCommand
        {
            get { return (ICommand)GetValue( CustomControlCommandProperty ); }
            set { SetValue( CustomControlCommandProperty, value ); }
        }
        public static readonly DependencyProperty CustomControlCommandProperty=
            DependencyProperty.Register( nameof( CustomControlCommand), typeof( ICommand ), typeof( OtlToggleButton ),
                new PropertyMetadata( null ) );
        // this is called in mouse down event handler
        private void PlayAnimation()
        {
            var myStoryboard = new Storyboard();
            myStoryboard.Completed += StoryboardCompleted;
            //.... animation
        }
        private void StoryboardCompleted( object sender, EventArgs e )
        {
            CustomControlCommand?.Execute(null);
        }
    }
