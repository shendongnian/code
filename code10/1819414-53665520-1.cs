    private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (textBlock!= null)
            {
                int column = Grid.GetColumn(textBlock);
                Storyboard storyboard = new Storyboard();
                ObjectAnimationUsingKeyFrames objectAnimationUsingKeyFrames = new ObjectAnimationUsingKeyFrames();
                DiscreteObjectKeyFrame discreteObjectKeyFrame = new DiscreteObjectKeyFrame();
                discreteObjectKeyFrame.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0));
                discreteObjectKeyFrame.Value = column;
                objectAnimationUsingKeyFrames.KeyFrames.Add(discreteObjectKeyFrame);
                Storyboard.SetTargetProperty(objectAnimationUsingKeyFrames, "(Grid.Column)");
                Storyboard.SetTarget(objectAnimationUsingKeyFrames, rect);
                storyboard.Children.Add(objectAnimationUsingKeyFrames);
                storyboard.Begin();
            }
        }
