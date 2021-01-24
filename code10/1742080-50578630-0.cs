      <Window.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation Storyboard.TargetProperty="Width" From="0" To="yourWidth" Duration="0:0:1" FillBehavior="HoldEnd" AutoReverse="False" />
                        <DoubleAnimation Storyboard.TargetProperty="Height" From="0" To="yourHeight" Duration="0:0:3" FillBehavior="HoldEnd" AutoReverse="False"/>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
     </Window.Triggers>
        I have hooked it for Window Loaded event but you can change it as you wish but the key is If you want smooth animation then you have to manually push frames in a timer or thread like:
      /// <summary>
        /// 
        /// </summary>
        public static class DispatcherHelper
        {
            /// <summary>
            /// Simulate Application.DoEvents function of <see cref=" System.Windows.Forms.Application"/> class.
            /// </summary>
            [SecurityPermissionAttribute ( SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode )]
            public static void DoEvents ( )
            {
                DispatcherFrame frame = new DispatcherFrame ( );
                Dispatcher.CurrentDispatcher.BeginInvoke ( DispatcherPriority.Background,
                    new DispatcherOperationCallback ( ExitFrames ), frame );
    
                try
                {
                    Dispatcher.PushFrame ( frame );
                }
                catch ( InvalidOperationException )
                {
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="f"></param>
            /// <returns></returns>
            private static object ExitFrames ( object frame )
            {
                ( ( DispatcherFrame ) frame ).Continue = false;
    
                return null;
            }
        }
