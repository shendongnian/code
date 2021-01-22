    public class ConvertToMp3Manager
    {
        public PrepareTranscodeResult PrepareTranscode = null;
        public MediaTranscoder TransCoder = null;
        public StorageFile SourceAudio { get; set; }
        public StorageFile DestinationAudio { get; set; }
        public AudioFormat AudioFormat { get; set; }
        public AudioEncodingQuality AudioQuality { get; set; }
        private MediaEncodingProfile profile = null;
        public  ConvertToMp3Manager(StorageFile sourceAudio, StorageFile destinationAudio, AudioFormat AudioType = AudioFormat.MP3, AudioEncodingQuality audioEncodingQuality = AudioEncodingQuality.High)
        {
            if (sourceAudio == null || destinationAudio == null)
                throw new ArgumentNullException("sourceAudio and destinationAudio cannot be null");
            switch (AudioType)
            {
                case AudioFormat.AAC:
                case AudioFormat.M4A:
                    profile = MediaEncodingProfile.CreateM4a(audioEncodingQuality);
                    break;
                case AudioFormat.MP3:
                    profile = MediaEncodingProfile.CreateMp3(audioEncodingQuality);
                    break;
                case AudioFormat.WMA:
                    profile = MediaEncodingProfile.CreateWma(audioEncodingQuality);
                    break;
            }
            this.SourceAudio = sourceAudio;
            this.DestinationAudio = destinationAudio;
            this.AudioFormat = AudioType;
            this.AudioQuality = audioEncodingQuality;
            this.TransCoder = new MediaTranscoder();
        }
        /// <summary>
        /// Return true if audio can be transcoded
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ConvertAudioAsync()
        {
            PrepareTranscode = await this.TransCoder.PrepareFileTranscodeAsync(this.SourceAudio, this.DestinationAudio, profile);
            if (PrepareTranscode.CanTranscode)
            {
                var transcodeOp = PrepareTranscode.TranscodeAsync();
                return true;
            }
            else
                return false;
        }
        public static async Task<bool> ConvertAudioAsync(StorageFile sourceAudio, StorageFile destinationAudio, AudioFormat AudioType = AudioFormat.MP3, AudioEncodingQuality audioEncodingQuality = AudioEncodingQuality.High)
        {
            ConvertToMp3Manager convertToMp3Manager = new ConvertToMp3Manager(sourceAudio, destinationAudio, AudioType, audioEncodingQuality);
            var success = await convertToMp3Manager.ConvertAudioAsync();
            return success;
        }
    }
    public enum AudioFormat
    {
        MP3,
        AAC,
        M4A,
        WMA
    }
