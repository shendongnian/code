    internal class SolKeyword : IClassifier
    {
        private readonly List<(Regex, IClassificationType)> _map;
        private readonly IClassificationType _typeClassification;
        /// <summary>
        /// Initializes a new instance of the <see cref="SolKeyword"/> class.
        /// </summary>
        /// <param name="registry">Classification registry.</param>
        internal SolKeyword(IClassificationTypeRegistryService registry)
        {
            _map = new List<(Regex, IClassificationType)>
            {
                (new Regex(@"/\*.+\*/", RegexOptions.Compiled | RegexOptions.Multiline), registry.GetClassificationType(Classification.SolComment)),
                (new Regex(@"//.+", RegexOptions.Compiled), registry.GetClassificationType(Classification.SolComment)),
                (new Regex(@""".*?""", RegexOptions.Compiled), registry.GetClassificationType(Classification.SolString)),
                (new Regex($@"\b({string.Join("|", VerboseConstant.BuiltinTypes.Concat(VerboseConstant.Keywords))})\b", RegexOptions.Compiled), registry.GetClassificationType(Classification.SolKeyword)),
                (new Regex($@"\b({VerboseConstant.Operators})\b", RegexOptions.Compiled), registry.GetClassificationType(Classification.SolKeyword)),
                (new Regex(@"\b-?(\d+(\.\d*)*)|(\.\d+)", RegexOptions.Compiled), registry.GetClassificationType(Classification.SolNumber)),
            };
            _typeClassification = registry.GetClassificationType(Classification.SolType);
        }
