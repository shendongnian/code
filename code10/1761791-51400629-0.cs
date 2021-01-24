    <GridView.ColumnHeaderContainerStyle>
		<Style TargetType="{x:Type GridViewColumnHeader}">
			<Setter Property="Width">
				<Setter.Value>
					<MultiBinding Converter="{StaticResource WidthConverter}" Mode="TwoWay">
						<Binding RelativeSource="{RelativeSource Mode=Self}"/>
						<Binding Source="{StaticResource parametersWidth}"/>
						<Binding RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType={x:Type ListView}, AncestorLevel=1}" Path="ActualWidth"/>
					</MultiBinding>
				</Setter.Value>
			</Setter>
	</GridView.ColumnHeaderContainerStyle>
