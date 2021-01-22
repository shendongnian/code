    /// <summary>
    /// Clears header/footer.
    /// </summary>
    /// <param name="rpt">The reportdocument</param>
    public static void ClearReportHeaderAndFooter(this ReportDocument rpt)
    {
		foreach (Section section in rpt.ReportDefinition.Sections)
		{
			if (section.Kind == AreaSectionKind.ReportHeader || section.Kind == AreaSectionKind.ReportFooter || section.Kind == AreaSectionKind.PageFooter || section.Kind == AreaSectionKind.PageHeader)
			{
				section.SectionFormat.EnableSuppress = true;
				section.SectionFormat.BackgroundColor = Color.White;
				foreach (var repO in section.ReportObjects)
				{
					if (repO is ReportObject)
					{
						var reportObject = repO as ReportObject;
						reportObject.ObjectFormat.EnableSuppress = true;
						reportObject.Border.BorderColor = Color.White;
					}
				}
			}
		}
    }
