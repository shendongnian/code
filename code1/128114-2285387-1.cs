public static explicit operator GridUnit(TableLayoutPanelCellPosition position)
{
    return new GridUnit(position.Column, position.Row;
}
public static explicit operator TableLayoutPanelCellPosition(GridUnit gridUnit)
{
    return new TableLayoutPanelCellPosition(gridUnit.Column, gridUnit.Row;
}
