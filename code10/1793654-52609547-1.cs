    public object Convert(
        object value, Type targetType, object parameter, CultureInfo culture)
    {
        var chapters = value as IEnumerable<Chapter>;
        return chapters == null
            ? "-"
            : string.Join(" ", chapters.Select(chap => chap.ChapterNumber));
    }
