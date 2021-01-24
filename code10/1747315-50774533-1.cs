    <Rectangle x:Name="aaa" >
      <Rectangle.Style>
        <Style TargetType="{x:Type Rectangle}" >
          <Setter Property="Fill">
            <Setter.Value>
              <ImageBrush ImageSource="pack://application:,,,/AssemblyName;component/Resources/Img1.png" />
            </Setter.Value>
          </Setter>
          <Style.Triggers>
            <DataTrigger Binding="{Binding Text.Length, ElementName=SearchTextBox}" Value="0" >
              <DataTrigger.Setters>
                <Setter Property="Fill">
                  <Setter.Value>
                    <ImageBrush ImageSource="pack://application:,,,/AssemblyName;component/Resources/Img2.png" />
                  </Setter.Value>
                </Setter>
              </DataTrigger.Setters>
            </DataTrigger>
          </Style.Triggers>
        </Style>
      </Rectangle.Style>
    </Rectangle>
