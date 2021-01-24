lang-c#
[System.Serializable]
public struct I18NTextData
{
    public string Label;
    public I18NTextDataTranslation[] translations;
}
[System.Serializable]
public struct I18NTextDataTranslation
{
    public string lang;
    public string content;
}
