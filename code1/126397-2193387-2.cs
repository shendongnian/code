    DestEnum de = DestEnum.DNone;
            SourceEnum se = SourceEnum.SA;
            Dictionary<int, int> maps = new Dictionary<int, int>();
            maps.Add((int)SourceEnum.SNone, (int)DestEnum.DNone);
            maps.Add((int)SourceEnum.SAB, (int)(DestEnum.DA | DestEnum.DB));
            maps.Add((int)SourceEnum.SA, (int)DestEnum.DA);
            de = (DestEnum)maps[(int)se];
