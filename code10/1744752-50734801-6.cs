    <VisualState x:Name="CompactClosed">
            <Storyboard>
                 <DoubleAnimationUsingKeyFrames Storyboard.TargetName="ContentControlTransform" Storyboard.TargetProperty="Y">
                      <DiscreteDoubleKeyFrame KeyTime="0:0:0" Value="{Binding TemplateSettings.CompactVerticalDelta, RelativeSource={RelativeSource Mode=TemplatedParent},Converter={StaticResource CompactVerticalDeltaConverter}}"/>
                 </DoubleAnimationUsingKeyFrames>
             </Storyboard>
    </VisualState>
