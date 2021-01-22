    <Style TargetType="ListBoxItem">
      <Setter Property="Template">
        <Setter.Value>
          <ControlTemplate TargetType="ListBoxItem">
            <DockPanel>
              <Button Content="ClickMe" Click="OnClickMeButtonClicked" />
              <ContentPresenter />
            </DockPanel>
          </ControlTemplate>
        </Setter.Value>
      </Setter>
    </Style>
