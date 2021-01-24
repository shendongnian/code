    class PathMakeCapAndJoinRound : PdfContentStreamEditor
    {
        protected override void Write(PdfContentStreamProcessor processor, PdfLiteral operatorLit, List<PdfObject> operands)
        {
            if (start)
            {
                initializeCapAndJoin(processor);
                start = false;
            }
            if (CAP_AND_JOIN_OPERATORS.Contains(operatorLit.ToString()))
            {
                return;
            }
            base.Write(processor, operatorLit, operands);
            if (GSTATE_OPERATOR == operatorLit.ToString())
            {
                initializeCapAndJoin(processor);
            }
        }
        void initializeCapAndJoin(PdfContentStreamProcessor processor)
        {
            PdfLiteral operatorLit = new PdfLiteral("J");
            List<PdfObject> operands = new List<PdfObject> { new PdfNumber(PdfContentByte.LINE_CAP_ROUND), operatorLit };
            base.Write(processor, operatorLit, operands);
            operatorLit = new PdfLiteral("j");
            operands = new List<PdfObject> { new PdfNumber(PdfContentByte.LINE_JOIN_ROUND), operatorLit };
            base.Write(processor, operatorLit, operands);
        }
        List<string> CAP_AND_JOIN_OPERATORS = new List<string> { "j", "J" };
        string GSTATE_OPERATOR = "gs";
        bool start = true;
    }
