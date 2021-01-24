    case "User":
        if (userId.HasValue)
        {
            var user = _userRepository.GetById(userId);
            var replacementValues = sourcekeyWords
                .Where(x => processedMessage.Contains(x))
                // .Key will be the keyword and .Value will have the replacement value
                .ToDictionary(x => x, x => GetPatientInfoFromUser(user, x));
            processedMessage = GetReplacementValue(replacementValues, processedMessage);
        }
        break;
