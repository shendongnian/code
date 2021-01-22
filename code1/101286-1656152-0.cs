    class MultiCriteriaFiltering
    {
        List<FilterCriteria> Criterias;
        // this method just sits here for simplicity - it should be in your DAL, not the DTO
        string BuildWhereCondition()
        {
            StringBuilder condition = new StringBuilder();
            condition.Append("WHERE (1=1) "
            foreach (FilterCriteria criteria in Criterias)
            {
                condition.Append(" AND ").Append(criteria.FieldName).Append(" = ");
                condition.Append("'").Append(criteria.FilterValue).Append("'");
            }
            return condition.ToString();
        }
    }
    class FilterCriteria
    {
        string FieldName { get; set; }
        object FilterValue  { get; set; }
    }
