    public class EDI_X12Grammar : IEdiGrammar
    {
    ...
    }
    var grammar = new EDI_X12Grammar() 
           {
                ComponentDataElementSeparator = new[] { '>' },
                DataElementSeparator = new[] { '*' },
                DecimalMark = null,
                ReleaseCharacter = null,
                Reserved = new char[0],
                SegmentTerminator = '~',
                ServiceStringAdviceTag = null,
                InterchangeHeaderTag = "ISA",
                FunctionalGroupHeaderTag = "GS",
                MessageHeaderTag = "ST",
                MessageTrailerTag = "SE",
                FunctionalGroupTrailerTag = "GE",
                InterchangeTrailerTag = "IEA",
            };
