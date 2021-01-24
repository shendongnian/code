     private void OnGetMemberAvatarCompleted(byte[] avatarBytes)
    {
       var avatarImageView = FindViewById<ImageView>(Resource.Id.memberProfile_avatar);
       if (avatarImageView != null)
       {
          var imageBitmap = BitmapFactory.DecodeByteArray(avatarBytes, 0,avatarBytes.Length);
          RunOnUiThread(() => avatarImageView.SetImageBitmap(imageBitmap));
       }
    }
