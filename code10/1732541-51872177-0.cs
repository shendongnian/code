    <!--Main Window-->
    xmlns:prism="http://prismlibrary.com/" 
    <Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition />
        <ColumnDefinition />
    </Grid.ColumnDefinitions>
    <Content Grid.Column="0" prism:RegionManager.RegionName="MainRegion1"/> 'Injects View1
    <Content Grid.Column="1" prism:RegionManager.RegionName="MainRegion2"/>
    <Grid>
    <!--View1 in MainRegion1-->
    <Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition />
        <ColumnDefinition />
    </Grid.ColumnDefinitions>
    <Content Grid.Column="0" prism:RegionManager.RegionName="SubRegion1"/>
    <Content Grid.Column="1" prism:RegionManager.RegionName="SubRegion2"/>
    <Grid>
