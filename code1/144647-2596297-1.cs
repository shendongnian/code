    var bubble = ... // some known bubble
    var sameColorBubblesBelowTheBubble =
         _theBubbles.Where( b => b.Column == bubble.Column &&
                            b.Row < bubble.Row )
                    .OrderByDescending( b => b.Row )
                    .TakeWhile( (b,i) =>  b.BubbleColor == bubble.BubbleColor );
               
