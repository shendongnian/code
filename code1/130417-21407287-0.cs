    <StackPanel Margin="90,328,965,389" Orientation="Horizontal">
            <RadioButton Content="Mr" Command="{Binding TitleCommand, Mode=TwoWay}" CommandParameter="{Binding Content, RelativeSource={RelativeSource Mode=Self}, Mode=TwoWay}" GroupName="Title"/>
            <RadioButton Content="Mrs" Command="{Binding TitleCommand, Mode=TwoWay}" CommandParameter="{Binding Content, RelativeSource={RelativeSource Mode=Self}, Mode=TwoWay}" GroupName="Title"/>
            <RadioButton Content="Ms" Command="{Binding TitleCommand, Mode=TwoWay}" CommandParameter="{Binding Content, RelativeSource={RelativeSource Mode=Self}, Mode=TwoWay}" GroupName="Title"/>
            <RadioButton Content="Other" Command="{Binding TitleCommand, Mode=TwoWay}" CommandParameter="{Binding Content, RelativeSource={RelativeSource Mode=Self}}" GroupName="Title"/>
            <TextBlock Text="{Binding SelectedTitle, Mode=TwoWay}"/>
        </StackPanel>
