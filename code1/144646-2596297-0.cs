    var bubble = ... // some known bubble
    var sameColorBubblesBelowTheBubble =
         _theBubbles.Where( b => b.Column == bubble.Column &&
                            b.Row < bubble.Row &&
                            b.BubbleColor == bubble.Color );
               
