    public interface IClsRtfDocParser
    {
        ClsRtfDoc ParseFromFile(string filePath);
    }
    public class ClsRtfDocParser:IClsRtfDocParser
    {
        public ClsRtfDoc ParseFromFile(string filePath)
        {
            int paperHeight = 0;
            //After reading the metadata, you reach the paper height line or something like that
            MatchCollection objPaperHeight = Regex.Matches(value, "(\\\\paperw\\d+)(\\\\paperh\\d*)");
            if (objPaperHeight.Count >= 1 && objPaperHeight[0].Groups.Count == 3){
                if (!(Int32.TryParse((objPaperHeight[0].Groups[2].Value).Replace("\\paperh", ""), out int paperHeightValue)))
                {
                    throw new FormatException("Invalid file format");
                }
                else
                {
                    paperHeight = paperHeightValue;
                }
            }
            return new ClsRtfDoc(paperHeight);
        }
    }
