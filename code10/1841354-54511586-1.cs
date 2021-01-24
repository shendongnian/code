    <UserControl
        xmlns:interact="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity" 
        ..>
        <Grid>
       
                <Button Height="25" Width="150">
                    <interact:Interaction.Triggers>
                        <interact:EventTrigger EventName="MouseEnter">
                        <interact:InvokeCommandAction Command="{Binding  MouseEnterCommand}" CommandParameter="MouseEnter" />
                        </interact:EventTrigger>
                    </interact:Interaction.Triggers>
                </Button>
          
        </Grid>
    </UserControl>
