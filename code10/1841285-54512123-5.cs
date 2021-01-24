        @Test
    public void threeColumnTableTest() throws IOException {
        PdfDocument pdfDocument = new PdfDocument(new PdfWriter(destinationFolder + "threeColumnTable.pdf"));
        Document document = new Document(pdfDocument, PageSize.A4.rotate());
        Rectangle[] columns = {new Rectangle(36, 36, 250, 423),
                new Rectangle(36 + 250 + 10, 36, 250, 423),
                new Rectangle(36 + 250 + 250 + 20, 36, 250, 423)};
        document.setRenderer(new ColumnDocumentRenderer(document, columns));
        TableHeaderEventHandler handler = new TableHeaderEventHandler();
        pdfDocument.addEventHandler(PdfDocumentEvent.START_PAGE, handler);
        Table table = new Table(3);
        for (int i = 0; i < 100; i++) {
            for (int j = 0; j < 3; j++) {
                table.addCell("row " + i + "column " + j);
            }
        }
        document.add(table);
        document.close();
    }
    public class TableHeaderEventHandler implements IEventHandler {
        @Override
        public void handleEvent(Event event) {
            PdfDocumentEvent docEvent = (PdfDocumentEvent) event;
            Canvas canvas = new Canvas(docEvent.getPage(), new Rectangle(36, 36 + 423, 780, 100));
            canvas.add(new Paragraph("Header").setTextAlignment(TextAlignment.CENTER));
        }
    }
