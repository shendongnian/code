            var anim = storyboard.Children[0] as DoubleAnimationUsingKeyFrames;
            anim.AutoReverse = true;
            anim.RepeatBehavior = RepeatBehavior.Forever;
    <Storyboard x:Key="Storyboard1">
			<DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="border" Storyboard.TargetProperty="(FrameworkElement.Width)">
				<SplineDoubleKeyFrame KeyTime="00:00:00" Value="200"/>
				<SplineDoubleKeyFrame KeyTime="00:00:00.5000000" Value="300"/>
			</DoubleAnimationUsingKeyFrames>
		</Storyboard>
 
