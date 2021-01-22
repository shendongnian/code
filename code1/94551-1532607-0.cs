    <Style x:Key="OnOffToggleImageStyle" TargetType="ToggleButton">
     <Style.Triggers>
       <Trigger Property="IsChecked" Value="True">
         <Setter Property="Content">
           <Setter.Value>
             <Image Source="C:\ON.jpg" />
           </Setter.Value>
         </Setter>
       </Trigger>
       <Trigger Property="IsChecked" Value="False">
         <Setter Property="Content">
           <Setter.Value>
             <Image Source="C:\OFF.jpg" />
           </Setter.Value>
         </Setter>
       </Trigger>
     </Style.Triggers>
    </Style>
