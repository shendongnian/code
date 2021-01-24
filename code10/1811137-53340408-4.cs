    for(int PI = 0; PI < MathHelper.Max(Monday.Count, Tuesday.Count, Wednesday.Count, Thursday.Count, Friday.Count, Saturday.Count, Sunday.Count); PI++)
    {
        Presentation.Add(new WeekRow(
            Monday.Count > PI ? Monday[PI] : null,
            Tuesday.Count > PI ? Tuesday[PI] : null,
            Wednesday.Count > PI ? Wednesday[PI] : null,
            Thursday.Count > PI ? Thursday[PI] : null,
            Friday.Count > PI ? Friday[PI] : null,
            Saturday.Count > PI ? Saturday[PI] : null,
            Sunday.Count > PI ? Sunday[PI] : null
            ));
    }
