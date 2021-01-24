    public string GetString(List<MeetingTypeModel> MeetingTypeList)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("({");
        foreach(MeetingTypeModel item in MeetingTypeList){
    
            sb.AppendFormat("\"{0}\":"\"{1}\", item.MeetingTypeId, item.MeetingTypeName);
            sb.Append(",");
        }
        sb.Append("})");
        return sb.ToString();
    }
