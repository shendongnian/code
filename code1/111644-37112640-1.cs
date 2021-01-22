    <TextBox Grid.Row="1" x:Name="MerchantReference" MaxLength="10" IsReadOnly="True"
                                 Text="{Binding MerchantReference, Mode=OneWay}"  >
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="MouseDoubleClick" >
                <i:InvokeCommandAction Command="{Binding MerchantReferenceCopyToClipboard}" />
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </TextBox>
