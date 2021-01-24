        StringBuilder SB = new StringBuilder();
        SB.Append("({");
        for(int i=0; i<MeetingTypeList.Count; i++) {
            MeetingTypeModel mtm = MeetingTypeList[i];
        
            SB.AppendFormat("\"{0}\":"\"{1}\", mtm.MeetingTypeId, mtm.MeetingTypeName);
            if {i<MeetingTypeList.Count -1) {
              SB.Append(",");
            }
        }
        SB.Append("})");
