    public static Dto ToDto((string, int) source , string[] nameMapping)
		{
			var dto = new Dto();
			var propertyInfo1 = typeof(Dto).GetProperty(nameMapping[0]);
			propertyInfo1?.SetValue(dto, source.Item1);
			var propertyInfo2 = typeof(Dto).GetProperty(nameMapping[1]);
			propertyInfo2?.SetValue(dto, source.Item2);
			return dto;
		}
