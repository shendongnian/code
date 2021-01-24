    public class MyTokenizer : Tokenizer<Tokens>
    {
        protected override IEnumerable<Result<Tokens>> Tokenize(TextSpan input)
        {
            Result<char> next = input.ConsumeChar();
            bool checkForHeader = true;
            while (next.HasValue)
            {
                // need to check for a header when starting a new line
                if (checkForHeader)
                {
                    var headerStartLocation = next.Location;
                    var tokenQueue = new List<Result<Tokens>>();
                    while (next.HasValue && (next.Value == 'X' || next.Value == 'Y'))
                    {
                        tokenQueue.Add(Result.Value(next.Value == 'X' ? Tokens.X : Tokens.Y, next.Location, next.Remainder));
                        next = next.Remainder.ConsumeChar();
                    }
                    // only if we had at least one X or one Y
                    if (tokenQueue.Any())
                    {
                        if (next.HasValue && next.Value == ':')
                        {
                            // this is a header token; we have to return a Result of the start location 
                            // along with the remainder at this location
                            yield return Result.Value(Tokens.Header, headerStartLocation, next.Remainder);
                            next = next.Remainder.ConsumeChar();
                        }
                        else
                        {
                            // this isn't a header; we have to return all the tokens we parsed up to this point
                            foreach (Result<Tokens> tokenResult in tokenQueue)
                            {
                                yield return tokenResult;
                            }
                        }
                    }
                    if (!next.HasValue)
                        yield break;
                }
                checkForHeader = false;
                if (next.Value == '\r') 
                {
                    // skip over the carriage return
                    next = next.Remainder.ConsumeChar();
                    continue;
                }
                if (next.Value == '\n')
                {
                    // line break; check for a header token here
                    next = next.Remainder.ConsumeChar();
                    checkForHeader = true;
                    continue;
                }
                if (next.Value == 'X')
                {
                    yield return Result.Value(Tokens.X, next.Location, next.Remainder);
                    next = next.Remainder.ConsumeChar();
                }
                else if (next.Value == 'Y')
                {
                    yield return Result.Value(Tokens.Y, next.Location, next.Remainder);
                    next = next.Remainder.ConsumeChar();
                }
                else if (next.Value == ':')
                {
                    yield return Result.Value(Tokens.Colon, next.Location, next.Remainder);
                    next = next.Remainder.ConsumeChar();
                }
                else if (next.Value == ' ')
                {
                    yield return Result.Value(Tokens.Space, next.Location, next.Remainder);
                    next = next.Remainder.ConsumeChar();
                }
                else
                {
                    yield return Result.Empty<Tokens>(next.Location, $"unrecognized `{next.Value}`");
                    next = next.Remainder.ConsumeChar(); // Skip the character anyway
                }
            }
        }
    }
