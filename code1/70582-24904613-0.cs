    return
                Enum
                .GetNames(typeof(ReceptionNumberType))
                .Where(i => (ReceptionNumberType)(Enum.Parse(typeof(ReceptionNumberType), i.ToString())) < ReceptionNumberType.MCI)
                .Select(i => new
                {
                    description = i,
                    value = (Enum.Parse(typeof(ReceptionNumberType), i.ToString()))
                });
