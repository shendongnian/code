    form.Add(new StringContent(appKey), "\"token\"");
    form.Add(new StringContent(userKey), "\"user\"");
    form.Add(new StringContent(message), "\"message\"");
    ...
    form.Add(imageParameter, "\"attachment\"", "image.png");
