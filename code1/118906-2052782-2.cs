    <Grid Background="Red" Height="100" Width="100">
        <Grid.ContextMenu>
            <ContextMenu>
                <MenuItem 
                    Header="Change status" 
                    Click="EditStatusCm_Click"
                    CommandParameter="{Binding RelativeSource={RelativeSource Self}, Path=Parent}" />
            </ContextMenu>
        </Grid.ContextMenu>
    </Grid>
