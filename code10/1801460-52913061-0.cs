    <FlowDocument>
      <Table>
        <!-- 
          This table has 3 columns, each described by a TableColumn 
          element nested in a Table.Columns collection element. 
        -->
        <Table.Columns>
          <TableColumn />
          <TableColumn />
          <TableColumn />
        </Table.Columns>
        <!-- 
          This table includes a single TableRowGroup which hosts 2 rows,
          each described by a TableRow element.
        -->
        <TableRowGroup>
          <!--
            Each of the 2 TableRow elements hosts 3 cells, described by
            TableCell elements.
          -->
          <TableRow>
            <TableCell>
              <!-- 
                TableCell elements may only host elements derived from Block.
                In this example, Paragaph elements serve as the ultimate content
                containers for the cells in this table.
              -->
              <Paragraph>Cell at Row 1 Column 1</Paragraph>
            </TableCell>
            <TableCell>
              <Paragraph>Cell at Row 1 Column 2</Paragraph>
            </TableCell>
            <TableCell>
              <Paragraph>Cell at Row 1 Column 3</Paragraph>
            </TableCell>
          </TableRow>
          <TableRow>
            <TableCell>
              <Paragraph>Cell at Row 2 Column 1</Paragraph>
            </TableCell>
            <TableCell>
              <Paragraph>Cell at Row 2 Column 2</Paragraph>
            </TableCell>
            <TableCell>
              <Paragraph>Cell at Row 2 Column 3</Paragraph>
            </TableCell>
          </TableRow>
        </TableRowGroup>
      </Table>
    </FlowDocument>
