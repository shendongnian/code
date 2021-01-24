+---------+-----------------------------------------------------+------------------------------------------------------------------------------+
|         |                        case-sensitive               |                               case-insensitive                               |
+---------+-----------------------------------------------------+------------------------------------------------------------------------------+
| pattern | Regex.Matches(input, "searchPattern")               | Regex.Matches(input, "searchPattern", RegexOptions.IgnoreCase)               |
| phrase  | Regex.Matches(input, Regex.Escape("searchPattern")) | Regex.Matches(input, Regex.Escape("searchPattern"), RegexOptions.IgnoreCase) |
+---------+-----------------------------------------------------+------------------------------------------------------------------------------+
