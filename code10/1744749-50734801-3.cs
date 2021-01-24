    <VisualState x:Name="CompactOpenUp">
                            <Storyboard>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetName="ContentTransform" Storyboard.TargetProperty="Y">
                                    <DiscreteDoubleKeyFrame KeyTime="0:0:0" Value="{Binding TemplateSettings.CompactVerticalDelta, RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                                </DoubleAnimationUsingKeyFrames>
    ......
