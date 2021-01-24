    public class NlpServiceDispatcher : INlpService
    {
        public async Task<NlpResult> AnalyzeAsync(string utterance)
        {
            var qnaResult = await _qnaMakerService.AnalyzeAsync(utterance);
            var luisResult = await _luisService.AnalyzeAsync(utterance);
            if (qnaResult.ConfidenceThreshold > luisResult.ConfidenceThreshold)
            {
                return qnaResult;
            }
            else
            {
                return luisResult;
            }
        }
    }
