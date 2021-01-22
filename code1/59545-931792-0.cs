    <Button Content="Right-click me">
        <Button.ContextMenu>
            <ContextMenu>
                <MenuItem>
                    <MenuItem.Header>
                        <StackPanel Orientation="Horizontal">
                            <TextBlock VerticalAlignment="Center">Menu item 1</TextBlock>
                            <Image Source="image.png" Height="50" />
                        </StackPanel>
                    </MenuItem.Header>
                </MenuItem>
            </ContextMenu>
        </Button.ContextMenu>
    </Button>
