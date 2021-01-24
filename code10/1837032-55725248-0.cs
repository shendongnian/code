        /// <summary>
        /// Will create a section properties
        /// </summary>
        /// <param name="orientation">The wanted orientation (landscape or portrai)</param>
        /// <returns>A section properties element</returns>
        public static SectionProperties CreateSectionProperties(PageOrientationValues orientation)
        {
            // create the section properties
            SectionProperties properties = new SectionProperties();
            // create the height and width
            UInt32Value height = orientation == (PageOrientationValues.Portrait) ? 16839U : 11907U;
            UInt32Value width = orientation != (PageOrientationValues.Portrait) ? 16839U : 11907U;
            // create the page size and insert the wanted orientation
            PageSize pageSize = new PageSize()
            {
                Width = width,
                Height = height,
                Code = (UInt16Value)9U,
                // insert the orientation
                Orient = orientation };
            // create the page margin
            PageMargin pageMargin = new PageMargin()
            {
                Top = 1417,
                Right = (UInt32Value)1417U,
                Bottom = 1417,
                Left = (UInt32Value)1417U,
                Header = (UInt32Value)708U,
                Footer = (UInt32Value)708U,
                Gutter = (UInt32Value)0U
            };
            Columns columns = new Columns() { Space = "720" };
            DocGrid docGrid = new DocGrid() { LinePitch = 360 };
            // appen the page size and margin
            properties.Append(pageSize, pageMargin, columns, docGrid);
            return properties;
        }
