    public string GetString(List<MeetingTypeModel> MeetingTypeList)
    {
    StringBuilder sb = new StringBuilder();
    sb.Append("({");
    int i = 1;
    foreach(MeetingTypeModel item in MeetingTypeList){
    
        sb.AppendFormat("\"{0}\" : \"{1}\"" , item.MeetingTypeId, item.MeetingTypeName);
        //To not append last comma
    	if(i != MeetingTypeList.Count)
        	sb.Append(",");
    	i++;
    }
    sb.Append("})");
    return sb.ToString();
    }
