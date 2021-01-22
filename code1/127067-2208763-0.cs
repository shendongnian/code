    <EventTrigger RoutedEvent="Button.Click">
      <EventTrigger.Actions>
        <BeginStoryboard>
          <Storyboard>
            <ColorAnimation Storyboard.TargetName="Stop2" Storyboard.TargetProperty="Color" To="Red" Duration="0" />
          </Storyboard>
        </BeginStoryboard>
      </EventTrigger.Actions>
    </EventTrigger>
